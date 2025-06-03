using Microsoft.AspNetCore.Authentication;
using My_Shop_Framework.Domain;
using System.Collections.Generic;

namespace TutorialManagement.Domain.TutorialVideo.Agg
{
    public class TutorialVideo : EntityBase
    {
        public string TitleFa { get; private set; }
        public string TitleEn { get; private set; }
        public string TitleAr { get; private set; }
        public string TitleRu { get; private set; }
        public string LinkFa { get; private set; }
        public string LinkEn { get; private set; }
        public string LinkAr { get; private set; }
        public string LinkRu { get; private set; }
        public string Poster { get; private set; }

        public TutorialVideo(string linkFa, string linkEn, string linkRu, string linkAr, string poster, string titleEn, string titleFa, string titleAr, string titleRu)
        {
            LinkFa = linkFa;
            LinkEn = linkEn;
            LinkRu = linkRu;
            LinkAr = linkAr;
            Poster = poster;
            TitleEn = titleEn;
            TitleFa = titleFa;
            TitleAr = titleAr;
            TitleRu = titleRu;
        }

        public void Edit(string titleEn, string titleFa, string titleAr, string titleRu, string linkFa, string linkEn, string linkRu, string linkAr, string poster)
        {
            TitleEn= titleEn;
            TitleFa= titleFa;
            TitleAr= titleAr;
            TitleRu= titleRu;
            LinkFa = linkFa;
            if (!string.IsNullOrWhiteSpace(linkEn))
                LinkEn = linkEn;
            if (!string.IsNullOrWhiteSpace(linkAr))
                LinkAr = linkAr;
            if (!string.IsNullOrWhiteSpace(linkRu))
                LinkRu = linkRu;
            if (!string.IsNullOrWhiteSpace(poster))
                Poster = poster;
        }
    }
}