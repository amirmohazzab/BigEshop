using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Shared
{
    public class SuccessMessages
    {
        #region Account
        public static string RegisterSuccessfullyDone = "ثبت نام شما با موفقیت انجام شد";
        public static string ForgotPasswordSuccessfullyDone = "کد تایید برای شماره موبایل شما ارسال شد";
        public static string ResetPasswordSuccessfullyDone = "تغییر کلمه عبور با موفقیت انجام شد";
        #endregion

        #region User

        public static string UpdateProfileSuccessfullyDone = "ویرایش حساب کاربری با موفقیت انجام شد";
		public static string CreateUserSuccessfullyDone = "حساب کاربری با موفقیت ایجاد شد";
        public static string EditUserSuccessfullyDone = "ویرایش حساب کاربری با موفقیت انجام شد";
        public static string DeleteUserSuccessfullyDone = "حذف حساب کاربری با موفقیت انجام شد";
        #endregion

        #region Product Category
        public static string CreateProductCategorySuccessfullyDone = "ایجاد دسته بندی با موفقیت انجام شد";
        public static string UpdateProductCategorySuccessfullyDone = "ویرایش دسته بندی با موفقیت انجام شد";
        public static string DeleteProductCategorySuccessfullyDone = "حذف دسته بندی با موفقیت انجام شد";
        #endregion
    }


    public class ErrorMessages
    {
        public static string OperationFailed = "خطایی رخ داده است لطفا بعدا تلاش کنید";
        public static string DuplicatedMobile = "کاربری با ابن شماره موبایل ثبت نام کرده است";

        #region User
        public static string UserIsBan = "حساب کاربری شما مسدود شده است";
        public static string UserIsNotActive = "حساب کاربری شما غیر فعال است";
        public static string UserNotFound = "کاربری یافت نشد";
        #endregion

        #region Role

        public static string NotSelectedRole = "نقشی انتخاب نشد";
        #endregion

        #region Product Category
        public static string ProductCategoryNotFound = "دسته بندی یافت نشد";

        #endregion

    }

    public class WarningMessages
    {
    }

    public class InfiMessages
    {
    }
}
