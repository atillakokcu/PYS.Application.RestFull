using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class FirmaIslemleri : BaseFirmaIslemleri
    {
        public TResult AddFirm(TblFirmalar Firma)
        {
            return base.DoAddFirm(Firma);
        }
        public TResult UpdateFirm(Guid FİrmGuid, TblFirmalar Firma)
        {
            return base.DoUpdateFirm(FİrmGuid, Firma);
        }
        public TResult DeleteFirm(Guid FİrmGuid, TblFirmalar Firma)
        {
            return base.DoDeleteFirm(FİrmGuid,Firma);
        }
        public TResult FirmList()
        {
            return base.DoFirmList();
        }
        public TResult FirmSearch(string Firmname)
        {
            return base.DoFirmSearch(Firmname);
        }
        public TResult FirmDetail(Guid FirmGuid)
        {
            return base.DoFirmDetail(FirmGuid);
        }
        public TResult PassiveFirm()
        {
            return base.DoPassiveFirm();
        }

    }
}
