﻿using MarketPlace.Data.Enums;
using MarketPlace.Data.Interfaces;
using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("Posts")]
    public class Post : DomainEntity<int>, IHasOwner, IHasSeoMetaData, IHasSoftDelete, ISwitchable, IDateTracking
    {
        [Required]
        public int OwnerId { get; set; }
        
        public int ProductId { get; set; }

        [StringLength(250)]
        
        public string Name { get; set; }

        [StringLength(500)]
        
        public string Description { get; set; }

        
        public string Content { get; set; }

        [StringLength(250)]
        
        public string Thumbnail { get; set; }

        [StringLength(250)]
        
        public string Image { get; set; }

        [StringLength(50)]
        
        public string ImageCaption { get; set; }

        public DateTime PublishedDate { get; set; }

        [StringLength(250)]
        
        public string Source { get; set; }

        public DateTime Hotdate { get; set; }

        public DateTime NewDate { get; set; }

        [StringLength(250)]
        
        public string SeoPageTitle { get; set; }

        [StringLength(250)]
        
        public string SeoAlias { get; set; }

        [StringLength(158)]
       
        public string SeoKeyWord { get; set; }

        [StringLength(158)]
        
        public string SeoDescription { get; set; }
        public bool IsDeleted { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual CusUser User { get; set; }
    }
}
