using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms
{
    public class EnvironmentNames
    {

        public static string GetTitle(Connections.Enums.Definitions.EnvironmentNames env)
        {
            switch (env)
            {
                case Connections.Enums.Definitions.EnvironmentNames.Accounting:
                    return "Hub_lblHubItemAccounting_Text";
                case Connections.Enums.Definitions.EnvironmentNames.SalesManagement:
                    return "Hub_lblHubItemSalesManagement_Text";
                case Connections.Enums.Definitions.EnvironmentNames.Warehouse:
                    return "Hub_lblHubItemWarehouse_Text";
                case Connections.Enums.Definitions.EnvironmentNames.Sales:
                    return "Hub_lblHubItemSales_Text";
                case Connections.Enums.Definitions.EnvironmentNames.Reporting:
                    return "Hub_lblHubItemReporting_Text";
                case Connections.Enums.Definitions.EnvironmentNames.Rahyab:
                    return "Hub_lblHubItemRahyab_Text";
                case Connections.Enums.Definitions.EnvironmentNames.Settings:
                    return "Hub_lblHubItemSettings_Text";
                case Connections.Enums.Definitions.EnvironmentNames.EMS:
                    return "HublblHubItemEMSText";
                case Connections.Enums.Definitions.EnvironmentNames.BackupAndRestore:
                    return "Hub_lblHubItemBackupAndRestore_Text";
                case Connections.Enums.Definitions.EnvironmentNames.SMS:
                    return "HublblSMSMANAGMENT";
                case Connections.Enums.Definitions.EnvironmentNames.BasicInformation:
                    return "HublblHubItemBasicInformationText";
                case Connections.Enums.Definitions.EnvironmentNames.Treasury:
                    return "HublblHubItemTreasuryText";
                case Connections.Enums.Definitions.EnvironmentNames.KalaGostaran:
                    return "HublblHubItemKalaGostaranText";

            }
            return "";
        }
    }
}
