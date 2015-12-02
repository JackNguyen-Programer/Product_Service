
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DALThongKe  /// nho chinh tinh trang cua hoa don
    {
        //public static List<ChiTietDH> GetChiTietDH(DateTime ngay)
        //{
        //    List<ChiTietDH> lctdh = new List<ChiTietDH>();
        //    QLBHEntities db = new QLBHEntities();
        //    var query = from ctdh in db.ChiTietDHs
        //                from dh in db.DonHangs
        //                where dh.NgayDH > ngay && dh.MaDH == ctdh.MaDH && dh.TinhTrang == "Đã giao"
        //           //     select ctdh;

        //                group ctdh by ctdh.MaSP into g
        //                select new { MaDH=1,MaSP=g.Key,SoLuong=g.Sum(p=>p.SoLuong) };
        //foreach(var item in query)
        //{
        //    ChiTietDH ct = new ChiTietDH();
        //    ct.MaDH = item.MaDH;
        //    ct.MaSP = item.MaSP;
        //    ct.SoLuong = item.SoLuong;
        //    lctdh.Add(ct);
        //    }
        //    return lctdh ;
        //}

        //public static List<ChiTietDNH> GetChiTietDNH(DateTime ngay)
        //{
        //    List<ChiTietDNH> lctdnh = new List<ChiTietDNH>();
        //    QLBHEntities db = new QLBHEntities();
        //    var query = from ctdnh in db.ChiTietDNHs
        //                from dnh in db.DonNhapHangs
        //                where dnh.NgayDNH > ngay && dnh.MaDNH == ctdnh.MaDNH
        //                group ctdnh by ctdnh.MaSP into g
        //                select new { MaDNH=1,MaSP=g.Key,SoLuong=g.Sum(p=>p.SoLuong) };

        //    foreach(var item in query)
        //    {
        //        ChiTietDNH ct = new ChiTietDNH();
        //        ct.MaDNH = item.MaDNH;
        //        ct.MaSP = item.MaSP;
        //        ct.SoLuong = item.SoLuong;
        //        lctdnh.Add(ct);
        //    }
        //    return lctdnh ;
      
        //}

        //public static List<SanPham> ThongKe(DateTime ngay)
        //{
        //    List<ChiTietDH> lctdh = GetChiTietDH(ngay);
        //    System.Console.WriteLine("So luong don hang " + lctdh.Count);
            
        //    List<ChiTietDNH> lctdnh = GetChiTietDNH(ngay);
        //    System.Console.WriteLine("So luong don nhap hang " + lctdnh.Count);
           
        //    QLBHEntities db = new QLBHEntities();
        //    var query = (from sp in db.SanPhams.AsNoTracking().AsEnumerable()
        //                           join dh in lctdh.AsEnumerable() on sp.MaSP equals dh.MaSP into inner
        //                           from dh in inner.DefaultIfEmpty(new ChiTietDH())
        //                           join dnh in lctdnh.AsEnumerable() on sp.MaSP equals dnh.MaSP into left
                              
        //                        from dnh in left.DefaultIfEmpty(new ChiTietDNH())
        //                 select new SanPham() { MaSP = sp.MaSP, TenSP = sp.TenSP, SoLuong = (((decimal?)dh.SoLuong ?? 0) + sp.SoLuong - ((decimal?)dnh.SoLuong ?? 0)) }).ToList();
            
                                   
        //    return query;
           
        //}

        //public static List<ChiTietDH> GetChiTietDH(DateTime tu,DateTime den)
        //{
        //    List<ChiTietDH> lctdh = new List<ChiTietDH>();
        //    QLBHEntities db = new QLBHEntities();
        //    var query = from ctdh in db.ChiTietDHs
        //                from dh in db.DonHangs
        //                where dh.NgayDH >= tu && dh.NgayDH <= den && dh.MaDH == ctdh.MaDH && dh.TinhTrang == "Đã giao"
        //                select ctdh;
        //    lctdh = query.ToList();
        //    return lctdh;
        //}

        //public static List<ChiTietDH> BaoCao(DateTime tu, DateTime den, decimal SLtu,decimal SLden)
        //{
        //    QLBHEntities db = new QLBHEntities();
        //     List<ChiTietDH> lctdh = GetChiTietDH(tu,den);
        //     System.Console.WriteLine(lctdh.Count);
            
        //     var query = from dh in lctdh
        //                 group dh by dh.MaSP into ct
        //                 where ct.Sum(c => c.SoLuong) >= SLtu && ct.Sum(c => c.SoLuong)<=SLden
        //                 select new ChiTietDH{MaSP=ct.Key ,MaDH=-1,SoLuong = ct.Sum(p => p.SoLuong) }; 
  
        //        return query.ToList();
        //}
    }
}