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

        #region Product
        public static string CreateProductSuccessfullyDone = "ایجاد محصول با موفقیت انجام شد";
        public static string UpdateProductSuccessfullyDone = "ویرایش محصول با موفقیت انجام شد";
        public static string DeleteProductSuccessfullyDone = "حذف محصول با موفقیت انجام شد";

        #endregion

        #region ProductGallery
        public static string CreateProductGallerySuccessfullyDone = "گالری محصول با موفقیت اضافه شد";
        public static string UpdateProductGallerySuccessfullyDone = "ویرایش گالری محصول با موفقیت انجام شد";
        public static string DeleteProductGallerySuccessfullyDone = "حذف گالری محصول با موفقیت انجام شد";

        #endregion

        #region Feature

        public static string CreateFeatureSuccessfullyDone = "ایجاد ویژگی با موفقیت انجام شد";
        public static string UpdateFeatureSuccessfullyDone = "ویرایش ویژگی با موفقیت انجام شد";
        public static string DeleteFeatureSuccessfullyDone = "حذف ویژگی با موفقیت انجام شد";

        #endregion

        #region Product Feature

        public static string CreateProductFeatureSuccessfullyDone = "ایجاد ویژگی محصول با موفقیت انجام شد";
        public static string UpdateProductFeatureSuccessfullyDone = "ویرایش ویژگی محصول با موفقیت انجام شد";
        public static string DeleteProductFeatureSuccessfullyDone = "حذف ویژگی محصول با موفقیت انجام شد";

        #endregion

        #region Product Color

        public static string CreateProductColorSuccessfullyDone = " رنگ محصول با موفقیت انجام شد";
        public static string UpdateProductColorSuccessfullyDone = "ویرایش رنگ محصول با موفقیت انجام شد";
        public static string DeleteProductColorSuccessfullyDone = "حذف رنگ محصول با موفقیت انجام شد";

        #endregion

        #region Role

        public static string CreateRoleSuccessfullyDone = "نقش با موفقیت ایجاد شد";
        public static string UpdateRoleSuccessfullyDone = "ویرایش نقش با موفقیت ایجاد شد";
        public static string DeleteRoleSuccessfullyDone = "حذف نقش با موفقیت ایجاد شد";
        #endregion
    }

    public class ErrorMessages
    {
        #region Account
        public static string OperationFailed = "خطایی رخ داده است لطفا بعدا تلاش کنید";
        public static string DuplicatedMobile = "کاربری با ابن شماره موبایل ثبت نام کرده است";
        #endregion

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

        #region Product
        public static string ProductNotFound = "محصول یافت نشد";

        #endregion

        #region Product Color

        public static string ProductColorNotFound = "رنگ محصول پیدا نشد";
        public static string ExistProductColor = "این رنگ برای این محصول قبلا ثبت شده است";
        #endregion

        #region Role

        public static string RoleNotFound = "نقش پیدا نشد";

        #endregion
        #region Product Gallery

        public static string ProductGalleryNotFound = "محصولی یافت نشد";

        #endregion

        #region Feature

        public static string FeatureNotFound = "ویژگی یافت نشد";
        #endregion

        #region Product Feature

        public static string ProductFeatureNotFound = "ویژگی محصول یافت نشد";
       
        #endregion

    }

    public class WarningMessages
    {
    }

    public class InfoMessages
    {
    }
}
