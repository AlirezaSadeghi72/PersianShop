using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.Enums
{
    public enum Overal_SettingEnum
    {
        TedChapFactor = 1,
        /// <summary>
        /// ماژول حسابدري
        /// </summary>
        Accounting = 74,
        /// <summary>
        /// مدت زمان ويرايش چك پرداختي
        /// </summary>
        EditPutCheck = 121,
        /// <summary>
        /// نمایش فرم شماره تلفن مشتري بعد از ثبت فاکتور فروشگاهی. خیر : 1 || همه مشتريان اجباري : 2 || همه مشتريان غير اجباري : 3 || فقط مشتري پيش فرض اجباري : 4 || فقط مشتري پيش فرض غير اجباري : 5
        /// </summary>
        ShowAddCellNumber = 259,
        /// <summary>
        /// منفي شدن انبار در برگشت از فروش، چك شود : 1  ||  گروه كالا : 2  ||  چك نشود : 3
        /// </summary>
        ManfiShodanAnbarDarEbtalBargashtAzForosh = 274,
        /// <summary>
        /// ثبت به تاریخ آینده. بله : 1 || خیر : 0
        /// </summary>
        FutureConfirm = 279,
        /// <summary>
        /// ارسال پیامک بعد از ثبت فاکتور فروشگاهی. بلی : 1 || خیر : 0
        /// </summary>
        SendSmsShopFactor = 280,
        /// <summary>
        /// ارسال پیامک فاکتور فروشگاهی با سوال . باسوال : 1 || بدون سوال : 0
        /// </summary>
        SendSmsShopFactorByQuestion = 281,
        /// <summary>
        /// متن پیامک برای فاکتور فروشگاهی.
        /// </summary>
        TextSmsShopFactor = 282,
        /// <summary>
        /// مانده مشتری به متن پیامک فاکتور فروشگاهی افزوده شود.  بلی : 1 || خیر : 0
        /// </summary>
        AddManCustonerToTextSmsShopFactor = 283,
        /// <summary>
        /// آيا در دريافت، شرح هر چك در عملكرد مشتري آورده شود؟
        /// </summary>
        SharhCheckDarAmalkardMoshtari = 284,
        /// <summary>
        /// آقاي / شركت Name مانده حساب شما به شركت Company مبلغ Man ريال مي‌باشد
        /// </summary>
        TxtManCus = 211,
        /// <summary>
        /// آیا در فرم های عملیاتی تاریخ سرور ملاک باشد
        /// </summary>
        DateCriterionFromServer = 285,
        /// <summary>
        /// آیا گروه كالا بر اساس نام مرتب شود
        /// </summary>
        SortByNameInGroupKala = 286,
        /// <summary>
        /// تعداد چاپ فيش واگذاري چک به حساب
        /// </summary>
        TedadFish = 13,
        /// <summary>
        /// تعداد چاپ قبض دريافت
        /// </summary>
        TedadChapDaryaft = 4,
        /// <summary>
        /// تعداد چاپ قبض پرداخت
        /// </summary>
        TedadChapPardakht = 5,
        /// <summary>
        /// زیرسیستم کالاگستر
        /// </summary>
        SubSystemKalaGostaran = 126,


    }
}
