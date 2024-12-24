using System.Net.Mail;

namespace Bytescove_Solutions.CommonServices
{
    public static class Util
    {
        public static string GetViewName(string pageType)
        {
            string viewName = pageType switch
            {
                { } s when s.StartsWith($"{PageType.AboutUs}") => ViewNameType.AboutUs,
                { } s when s.StartsWith($"{PageType.ContactUs}") => ViewNameType.ContactUs,
                { } s when s.StartsWith($"{PageType.OurTeam}") => ViewNameType.OurTeam,
                { } s when s.StartsWith($"{PageType.Portfolio}") => ViewNameType.Portfolio,
                { } s when s.StartsWith($"{PageType.Blog}") => ViewNameType.Blog,
                { } s when s.StartsWith($"{PageType.Career}") => ViewNameType.Career,
                { } s when s.StartsWith($"{PageType.Industry}") => ViewNameType.Industry,
                { } s when s.StartsWith($"{PageType.WebDevelopment}") => ViewNameType.WebDevelopment,
                { } s when s.StartsWith($"{PageType.MobileAppDevelopment}") => ViewNameType.MobileAppDevelopment
            };

            return viewName;
        }
        public static void SendMail(string strTo, string strSubject, string strBody, string strBccMail, IFormFile Attachment)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.To.Add("business@coherentlab.com");
                //mailMsg.To.Add("mohitjangid.work@gmail.com");
                mailMsg.From = new MailAddress("noreply@coherentlab.com", "Coherent Lab");
                mailMsg.Subject = strSubject;
                mailMsg.Body = strBody;
                if (Attachment != null)
                {
                    if (Attachment.Length > 0)
                    {
                        string fileName = Path.GetFileName(Attachment.FileName);
                        mailMsg.Attachments.Add(new Attachment(Attachment.OpenReadStream(), fileName));
                    }
                }
                mailMsg.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.zoho.com", 587);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("noreply@coherentlab.com", "Uz!6a2z7#");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public static class ViewNameType
    {
        public static string AboutUs = "AboutUs";
        public static string ContactUs = "ContactUs";
        public static string OurTeam = "OurTeam";
        public static string Portfolio = "Portfolio";
        public static string Blog = "Blog";
        public static string Career = "Career";
        public static string Industry = "Industry";
        public static string WebDevelopment = "WebDevelopment";
        public static string MobileAppDevelopment = "MobileAppDevelopment";
    }
    public static class PageType
    {
        public static string AboutUs = "about-us";
        public static string ContactUs = "contact-us";
        public static string OurTeam = "our-team";
        public static string Portfolio = "portfolio";
        public static string Blog = "blog";
        public static string Career = "career";
        public static string Industry = "industry";
        public static string WebDevelopment = "web-development";
        public static string MobileAppDevelopment = "mobile-app-development";
    }
}