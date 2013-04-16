﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YangKai.BlogEngine.Modules.PostModule.Objects;

namespace YangKai.BlogEngine.Web.Mvc.Models
{
    public class PostViewModel
    {
        public Guid PostId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
        public DateTime PubDate { get; set; }

        public PostStatusEnum PostStatus { get; set; }
        public CommentStatusEnum CommentStatus { get; set; }

        public string ChannelName { get; set; }
        public string ChannelUrl { get; set; }
        public string GroupName { get; set; }
        public string GroupUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string QrCodeUrl { get; set; }

        public Dictionary<string, string> Category { get; set; }
        public IList<string> Tags { get; set; }
    }

    public static class PostViewModelExtension
    {
        public static PostViewModel ToViewModel(this Post entity)
        {
            var viewModel= new PostViewModel()
            {
                PostId = entity.PostId,
                Url = entity.Url,
                Title = entity.Title,
                Content = entity.Pages[0].Content,
                Description = entity.Description,
                Author = entity.PubAdmin.UserName,
                ViewCount = entity.ViewCount,
                ReplyCount = entity.ReplyCount,
                PubDate = entity.PubDate,
                PostStatus = (PostStatusEnum)entity.CommentStatus,
                CommentStatus = (CommentStatusEnum)entity.CommentStatus,
                ChannelName = entity.Group.Channel.Name,
                ChannelUrl = entity.Group.Channel.Url,
                GroupName = entity.Group.Name,
                GroupUrl = entity.Group.Url,
                ThumbnailUrl=entity.Thumbnail.Url,
                QrCodeUrl=entity.QrCode.Url
            };
            entity.Categorys.ForEach(p => viewModel.Category.Add(p.Url,p.Name));
            entity.Tags.ForEach(p => viewModel.Tags.Add(p.Name));

            return viewModel;
        }

        public static IList<PostViewModel> ToViewModels(this IList<Post> entities)
        {
            var list = new List<PostViewModel>();
            entities.ToList().ForEach(p =>
            {
                var viewModel = p.ToViewModel();
                list.Add(viewModel);
            });
            return list;
        }
    }
}