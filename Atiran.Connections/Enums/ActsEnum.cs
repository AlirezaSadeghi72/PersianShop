using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.Enums
{
    public enum ActsEnum
    {
        /// <summary>
        /// دريافت حواله
        /// </summary>
        DaryaftPosVaHavale = 8,
        /// <summary>
        /// پرداخت حواله
        /// </summary>
        PardakhtPosVaHavale = 9,
        /// <summary>
        /// ابطال فروش
        /// </summary>
        EbtalForosh = 17,
        /// <summary>
        /// برگشت از فروش
        /// </summary>
        BargashtAzForosh = 21,
        /// <summary>
        /// سند حسابداري
        /// </summary>
        SanadHesabdari = 59,
        /// <summary>
        /// ابطال برگشت از فروش
        /// </summary>
        /// 
        EbtalBargashtAzForosh = 84,
        /// <summary>
        /// كارمزد بانكي در پرداخت
        /// </summary>
        KarmozBankiInPardakht = 81,
        
    }
}
