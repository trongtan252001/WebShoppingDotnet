using System;
using System.Collections;
using System.Globalization;

namespace WebShoppingDotnet.utilt
{
    public class ProductFotmat
    {
        public static String getTrangThai(int trangThai)
        {
            switch (trangThai)
            {
                case 0:
                    return "Hết hàng";
                case 1:
                    return "Còn hàng";
                case 2:
                    return "Tạm ngừng";
                default:
                    return "";
            }
        }
        public static String getClassTrangThai(int trangThai)
        {
            switch (trangThai)
            {
                case 0:
                    return "alert-danger";
                case 1:
                    return "alert-success";
                case 2:
                    return "alert-warning";
                default:
                    return "";
            }
        }
        public static String getClassTrangThai2(int status)
        {
            switch (status)
            {
                case 0:
                    return "alert-warning";
                case 1:
                    return "alert-danger";
                case 2:
                    return "alert-primary";
                case 3:
                    return "alert-info";
                case 4:
                    return "alert-success";
                default:
                    return "alert-warning";
            }
        }
        public static String getTrangThai2(int status)
        {
            switch (status)
            {
                case 0:
                    return "Chờ xác nhận";
                case 1:
                    return "Đã hủy";
                case 2:
                    return "Đã xác nhận";
                case 3:
                    return "Đang giao hàng";
                case 4:
                    return "Đã giao hàng";
                default:
                    return "Chờ xác nhận";
            }
        }
        public static String formatPrice(double price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string a = double.Parse(price+"").ToString("#,###", cul.NumberFormat);
            return a;
        }
    }
}
