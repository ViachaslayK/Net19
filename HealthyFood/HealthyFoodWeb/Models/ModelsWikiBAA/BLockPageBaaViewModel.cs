﻿namespace HealthyFoodWeb.Models.ModelsWikiBAA
{
    public class BLockPageBaaViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public int CountImg { get; set; }

        public List<IFormFile> CoverFiles { get; set; }

        public List<WikiBlockImgViewModel> Img { get; set; }

        public List<CommentAndAuthorViewModel> CommentAndAuthor { get; set; }
    }
}

