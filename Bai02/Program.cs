using System;

class Program
{
    static void Main()
    {
        QuanLyPhuongTien ql = new QuanLyPhuongTien();

        while (true)
        {
            Console.WriteLine("\n===== QUẢN LÝ PHƯƠNG TIỆN  =====");
            Console.WriteLine("1. Thêm ô tô");
            Console.WriteLine("2. Thêm xe máy");
            Console.WriteLine("3. Hiển thị tất cả phương tiện");
            Console.WriteLine("4. Tìm phương tiện có giá lăn bánh cao nhất");
            Console.WriteLine("5. Tìm phương tiện theo tên hãng");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn: ");

            string luaChon = Console.ReadLine();

            try
            {
                switch (luaChon)
                {
                    case "1":
                        ThemOTo(ql);
                        break;

                    case "2":
                        ThemXeMay(ql);
                        break;

                    case "3":
                        ql.DisplayAll();
                        break;

                    case "4":
                        TimGiaCaoNhat(ql);
                        break;

                    case "5":
                        TimTheoTenHang(ql);
                        break;

                    case "0":
                        Console.WriteLine("Đã thoát chương trình.");
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }

    // Nhập và thêm ô tô
    static void ThemOTo(QuanLyPhuongTien ql)
    {
        Console.WriteLine("\n===== THÊM Ô TÔ =====");

        Console.Write("Mã phương tiện: ");
        string maPT = Console.ReadLine();

        Console.Write("Tên hãng: ");
        string tenHang = Console.ReadLine();

        Console.Write("Năm sản xuất: ");
        int namSanXuat = int.Parse(Console.ReadLine());

        Console.Write("Giá gốc: ");
        decimal giaGoc = decimal.Parse(Console.ReadLine());

        Console.Write("Số chỗ ngồi: ");
        int soChoNgoi = int.Parse(Console.ReadLine());

        Console.Write("Dung tích động cơ (L): ");
        double dungTichDongCo = double.Parse(Console.ReadLine());

        OTo oto = new OTo(
            maPT,
            tenHang,
            namSanXuat,
            giaGoc,
            soChoNgoi,
            dungTichDongCo
        );

        ql.AddPhuongTien(oto);

        Console.WriteLine("=> Thêm ô tô thành công!");
    }

    // Nhập và thêm xe máy
    static void ThemXeMay(QuanLyPhuongTien ql)
    {
        Console.WriteLine("\n===== THÊM XE MÁY =====");

        Console.Write("Mã phương tiện: ");
        string maPT = Console.ReadLine();

        Console.Write("Tên hãng: ");
        string tenHang = Console.ReadLine();

        Console.Write("Năm sản xuất: ");
        int namSanXuat = int.Parse(Console.ReadLine());

        Console.Write("Giá gốc: ");
        decimal giaGoc = decimal.Parse(Console.ReadLine());

        Console.Write("Dung tích xy lanh (cc): ");
        int dungTichXylanh = int.Parse(Console.ReadLine());

        XeMay xeMay = new XeMay(
            maPT,
            tenHang,
            namSanXuat,
            giaGoc,
            dungTichXylanh
        );

        ql.AddPhuongTien(xeMay);

        Console.WriteLine("=> Thêm xe máy thành công!");
    }

    // Tìm phương tiện có giá lăn bánh cao nhất
    static void TimGiaCaoNhat(QuanLyPhuongTien ql)
    {
        Console.WriteLine("\n===== PHƯƠNG TIỆN GIÁ LĂN BÁNH CAO NHẤT =====");

        PhuongTien max = ql.FindMaxGiaLanBanh();

        if (max == null)
        {
            Console.WriteLine("Danh sách phương tiện đang trống!");
            return;
        }

        Console.WriteLine(max.GetInfo());
        Console.WriteLine(
            $"Giá lăn bánh: {max.TinhGiaLanBanh():N0} VNĐ"
        );
    }

    // Tìm phương tiện theo tên hãng
    static void TimTheoTenHang(QuanLyPhuongTien ql)
    {
        Console.WriteLine("\n===== TÌM KIẾM THEO TÊN HÃNG =====");

        Console.Write("Nhập tên hãng cần tìm: ");
        string keyword = Console.ReadLine();

        var ketQua = ql.SearchByName(keyword);

        if (ketQua.Count == 0)
        {
            Console.WriteLine("Không tìm thấy phương tiện!");
            return;
        }

        Console.WriteLine($"Tìm thấy {ketQua.Count} phương tiện:");

        foreach (PhuongTien pt in ketQua)
        {
            Console.WriteLine(pt.GetInfo());
            Console.WriteLine(
                $"Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ"
            );
            Console.WriteLine("----------------------------");
        }
    }
}