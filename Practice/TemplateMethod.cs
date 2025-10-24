using System;

abstract class ReportGenerator {
    public void Generate() {
        GetData();
        Format();
        Save();
    }
    protected abstract void GetData();
    protected abstract void Format();
    protected virtual void Save() => Console.WriteLine("Сохранено");
}

class PdfReport : ReportGenerator {
    protected override void GetData() => Console.WriteLine("Данные для PDF");
    protected override void Format() => Console.WriteLine("Форматирование PDF");
}

class ExcelReport : ReportGenerator {
    protected override void GetData() => Console.WriteLine("Данные для Excel");
    protected override void Format() => Console.WriteLine("Форматирование Excel");
    protected override void Save() => Console.WriteLine("Excel сохранён в файл");
}

class Program2 {
    static void Main() {
        ReportGenerator r1 = new PdfReport();
        ReportGenerator r2 = new ExcelReport();
        r1.Generate();
        r2.Generate();
    }
}
