using System;

public class XeMay : PhuongTien
{
    public int DungTichXylanh { get; set; }

    public XeMay(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (dungTichXylanh <= 0)
            throw new ArgumentException(
                "Dung tích xy lanh phải lớn hơn 0.");

        DungTichXylanh = dungTichXylanh;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
        {
            return GiaGoc + GiaGoc * 0.02m;
        }

        return GiaGoc + GiaGoc * 0.05m;
    }

    public override string GetInfo()
    {
        return base.GetInfo()
            + $", Dung tích xy lanh: {DungTichXylanh}cc";
    }
}