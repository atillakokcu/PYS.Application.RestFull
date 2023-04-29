using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class BaseFirmaIslemleri
    {
        private DbPYSEntities Db;

        public BaseFirmaIslemleri()
        {
            Db = new DbPYSEntities();

        }

        internal TResult DoAddFirm(TblFirmalar Firma)
        {
            TResult result = new TResult();

            try
            {
                Db.TblFirmalar.Add(Firma);
                Db.SaveChanges();
                result.StatusCode = 200;
                result.Success = true;


            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }

        internal TResult DoUpdateFirm(Guid FİrmGuid, TblFirmalar Firma)
        {
            TResult result = new TResult();

            try
            {
                TblFirmalar Firm = (from data in Db.TblFirmalar where data.FirmaGuid == FİrmGuid select data).FirstOrDefault();

                if (Firm == null)
                {
                    result.Success = false;
                    result.Message = "firma bulunamadı";
                }

                else
                {
                    Firm = Firma;
                    Db.TblFirmalar.Add(Firma);
                    Db.SaveChanges();
                    result.StatusCode = 200;
                    result.Success = true;

                }



            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }

        internal TResult DoDeleteFirm(Guid FİrmGuid, TblFirmalar Firma)
        {
            TResult result = new TResult();

            try
            {
                TblFirmalar Firm = (from data in Db.TblFirmalar where data.FirmaGuid == FİrmGuid select data).FirstOrDefault();

                if (Firm == null)
                {
                    result.Success = false;
                    result.Message = "firma bulunamadı";
                }

                else
                {
                    Db.Database.ExecuteSqlCommand("update TblFirmalar set Silik=1 where FirmaGuid='" + FİrmGuid.ToString() + "'");
                    Db.TblFirmalar.Add(Firma);
                    Db.SaveChanges();
                    result.StatusCode = 200;
                    result.Success = true;

                }



            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }

        internal TResult DoFirmList()
        {
            TResult result = new TResult();

            try
            {
                List<VwTblFirmalar> FirmList = (from data in Db.VwTblFirmalar orderby data.FirmaUnvan select data).ToList();

                if (FirmList == null)
                {
                    result.Success = false;
                    result.Message = "firma bulunamadı";
                }

                else
                {
                    result.Data.AddRange(FirmList); //addrange, listenin içine listeyi komple koyar
                    result.StatusCode = 200;
                    result.Success = true;

                }



            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }

        internal TResult DoFirmSearch(string Firmname)
        {
            TResult result = new TResult();

            try
            {
                List<VwTblFirmalar> FirmList = (from data in Db.VwTblFirmalar where data.FirmaUnvan.Contains(Firmname) || data.FirmaKodu.ToString().Contains(Firmname) select data).ToList();

                if (FirmList == null)
                {
                    result.Success = false;
                    result.Message = "firma bulunamadı";
                }

                else
                {
                    result.Data.AddRange(FirmList); //addrange, listenin içine listeyi komple koyar
                    result.StatusCode = 200;
                    result.Success = true;

                }



            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }

        internal TResult DoFirmDetail(Guid FirmGuid)
        {
            TResult result = new TResult();

            try
            {
                VwTblFirmalar FirmDetay = (from data in Db.VwTblFirmalar where data.FirmaGuid.Value == FirmGuid select data).FirstOrDefault();

                if (FirmDetay == null)
                {
                    result.Success = false;
                    result.Message = "firma bulunamadı";
                }

                else
                {
                    result.Data.Add(FirmDetay); //addrange, listenin içine listeyi komple koyar
                    result.StatusCode = 200;
                    result.Success = true;

                }



            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }

        internal TResult DoPassiveFirm()
        {
            TResult result = new TResult();

            try
            {
                List<VwFirmalar> FirmListPassive = (from data in Db.VwFirmalar where data.Aktif != true select data).ToList();

                if (FirmListPassive == null)
                {
                    result.Success = false;
                    result.Message = "firma bulunamadı";
                }

                else
                {
                    result.Data.AddRange(FirmListPassive); //addrange, listenin içine listeyi komple koyar
                    result.StatusCode = 200;
                    result.Success = true;

                }



            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Message = ex.Message;
            }

            return result;

        }


    }

}
