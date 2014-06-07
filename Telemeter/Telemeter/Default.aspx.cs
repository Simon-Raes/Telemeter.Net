using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telemeter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                TelemeterService.RetrieveUsageRequestType req = new TelemeterService.RetrieveUsageRequestType();
                req.UserId = txtLogin.Text;
                req.Password = txtPassword.Text;

                TelemeterService.TelemeterService service = new TelemeterService.TelemeterService();
                TelemeterService.RetrieveUsageResponseType response = service.retrieveUsage(req);
                String telenetType = response.Item.ToString();

                if (telenetType.Equals("Telemeter.TelemeterService.FUPType"))
                {
                    DateTime day = response.Ticket.ExpiryTimestamp;
                    TelemeterService.FUPType fupType = (TelemeterService.FUPType)response.Item;

                    //usage
                    decimal totalUsed = fupType.Usage.TotalUsage;
                    decimal maxMin = fupType.Usage.MinUsageRemaining;
                    decimal maxMax = fupType.Usage.MaxUsageRemaining;
                    lblTotalUsed.Text = totalUsed.ToString() + fupType.Usage.Unit.ToString();
                    lblMaxOne.Text = maxMin.ToString() + fupType.Usage.Unit.ToString();
                    lblMaxTwo.Text = maxMax.ToString() + fupType.Usage.Unit.ToString();

                    //period
                    DateTime from = fupType.Period.From;
                    DateTime till = fupType.Period.Till;
                    lblFrom.Text = from.Date.ToString();
                    lblTill.Text = till.Date.ToString();

                    //status
                    String status = fupType.Status.ToString();
                    lblStatus.Text = fupType.Status.ToString();

                    if (status.Equals("Grootverbruik"))
                    {
                        //Extra info only available in case of "Grootverbruik" status
                        DateTime startVrijVerbruik = fupType.Info.StartVrijVerbruik;
                        DateTime startGrootverbruiker = fupType.Info.StartGrootverbruiker;
                    }
                }
                else
                {
                    //Not using FUP
                    TelemeterService.VolumeType volumeType = (TelemeterService.VolumeType)response.Item;
                    TelemeterService.DailyUsageType[] dailyUsages = volumeType.DailyUsageList;
                }
            }
            catch (Exception ex)
            {
                //should only catch SOAPException
                lblStatus.Text = ex.Message;
            }
        }

    }
}