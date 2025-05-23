﻿using BigEshop.Domain.Enums.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.User
{
	public class AdminSideEditUserViewModel
	{
        public int Id { get; set; }

        [Display(Name = "نام")]
		[MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string? FirstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string? LastName { get; set; }

		[Display(Name = "موبایل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string Mobile { get; set; }

		[Display(Name = "ایمیل")]
		[MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string? Email { get; set; }

		[Display(Name = "وضعیت کاربر")]
		public UserStatus Status { get; set; }

		[Display(Name = "نقش ها")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public List<int>? RoleIds { get; set; }

        [Display(Name = "تصویر")]
        public string? Avatar { get; set; }

        [Display(Name = "تصویر")]
		public IFormFile? NewAvatar { get; set; }
}

	public enum AdminSideEditUserResult
	{
		Success,
		MobileDuplicated,
		NotSelectedRole,
		UserNotFound
	}
}
