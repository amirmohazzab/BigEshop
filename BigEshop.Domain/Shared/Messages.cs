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

    }

    public class WarningMessages
    {
    }

    public class InfiMessages
    {
    }
}
