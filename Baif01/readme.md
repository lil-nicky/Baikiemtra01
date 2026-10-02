Câu 1: Trình bày sự khác nhau giữa Value Types và Reference Types trong C# về cơ chế lưu trữ vùng nhớ (Stack vs Heap).

Trong C#, Value Types là kiểu dữ liệu lưu trữ trực tiếp giá trị của biến. Khi một Value Type được gán cho một biến khác thì giá trị sẽ được sao chép sang biến mới. Một số kiểu Value Type phổ biến là int, float, bool, struct,...

Reference Types không lưu trực tiếp dữ liệu mà lưu một tham chiếu đến đối tượng chứa dữ liệu trong bộ nhớ. Khi gán một Reference Type cho biến khác thì hai biến có thể cùng tham chiếu đến một đối tượng. Một số Reference Type phổ biến là class, array, string và object.

Về bộ nhớ, có thể hiểu đơn giản rằng Value Type thường được lưu trên Stack, còn đối tượng của Reference Type thường được lưu trên Heap. Tuy nhiên, vị trí chính xác còn phụ thuộc vào ngữ cảnh sử dụng. Điểm khác nhau quan trọng nhất là Value Type chứa trực tiếp giá trị, còn Reference Type chứa tham chiếu đến đối tượng.

Câu 2: Tính năng Init-only Properties (init) trong C# 9/10 khác gì so với thuộc tính có set thông thường? Nêu trường hợp sử dụng thực tế.

init là một tính năng được giới thiệu từ C# 9, cho phép thuộc tính chỉ được gán giá trị trong quá trình khởi tạo đối tượng. Sau khi đối tượng được khởi tạo xong thì giá trị của thuộc tính không thể thay đổi.

Trong khi đó, thuộc tính sử dụng set thông thường có thể được thay đổi giá trị bất cứ lúc nào sau khi đối tượng được tạo.

Ví dụ, với init:

class Student
{
    public string Name { get; init; }
}

Có thể khởi tạo:

Student student = new Student { Name = "Nam" };

Nhưng sau đó không thể thực hiện student.Name = "An".

Trong thực tế, init thường được sử dụng cho những thông tin cần cố định sau khi đối tượng được khởi tạo, ví dụ như mã sinh viên, mã sản phẩm hoặc các thông tin cấu hình. Điều này giúp hạn chế việc vô tình thay đổi dữ liệu sau khi đối tượng đã được tạo.

Câu 3: Phân biệt sự khác nhau giữa phương thức virtual ở lớp cha và phương thức override ở lớp con khi triển khai tính Đa hình (Polymorphism).

virtual được sử dụng trong lớp cha để khai báo một phương thức có thể được thay đổi cách thực hiện ở lớp con. Nó tạo điều kiện để lớp con có thể ghi đè phương thức đó.

override được sử dụng trong lớp con để cung cấp một cách triển khai mới cho phương thức virtual của lớp cha.

Ví dụ:

class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Âm thanh của động vật");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Gâu gâu");
    }
}

Khi sử dụng:

Animal animal = new Dog();
animal.Sound();

kết quả sẽ là Gâu gâu. Điều này thể hiện tính đa hình, bởi vì biến có kiểu Animal nhưng đối tượng thực tế là Dog, nên phương thức override của lớp Dog được thực hiện.

Câu 4: Tại sao một thành phần được khai báo là static trong Class lại không thể truy xuất thông qua một Object Instance được tạo bằng toán tử new?

Thành phần được khai báo là static thuộc về Class chứ không thuộc về từng Object Instance. Vì vậy, khi tạo nhiều đối tượng bằng từ khóa new, các đối tượng đó không có bản sao riêng của thành phần static.

Thành phần static chỉ có một bản duy nhất và được dùng chung cho toàn bộ Class. Do đó, cách truy xuất đúng là thông qua tên Class.

Ví dụ:

class Student
{
    public static int Count = 0;
}

Có thể truy xuất bằng:

Student.Count;

Thay vì truy xuất thông qua một đối tượng:

Student student = new Student();
student.Count; // Không được phép
Static thuộc về Class nên được truy xuất thông qua tên Class, còn các thành phần không có static thuộc về từng Object Instance và được truy xuất thông qua đối tượng.
