using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace InstagramStalker
{
    public class GetProfile
    {
        string instagramLink = "https://www.instagram.com/";
        string userName = "";

        public GetProfile(string UserName)
        {
            userName = UserName;
        }

        private string GetHtmlContent()
        {
            Uri url = new Uri(instagramLink + userName);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string html = client.DownloadString(url);
            return html;
        }

        private string GetPictureLink()
        {
            string htmlDoc = GetHtmlContent();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlDoc);
            var node = document.DocumentNode.SelectNodes("//meta");
            return node[14].Attributes[1].Value;
        }

        public string ZoomPictureLink()
        {

            string pictureLink = GetPictureLink();
            int startVp = pictureLink.IndexOf("/vp/");
            int finalT52 = pictureLink.IndexOf("/t51");
            string first = pictureLink.Remove(startVp, finalT52 - startVp);

            return first.Replace("s150x150","");
        }

    }
}