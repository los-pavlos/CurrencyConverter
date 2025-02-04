# Currency Converter

Jednoduchá WPF aplikace pro převod měn pomocí API **Frankfurter.app**.

## 🛠️ Funkce
- Výběr měn pro převod
- Načítání aktuálních kurzů z API
- Převod z jedné měny do druhé

## 📦 Požadavky
- .NET 6+ nebo .NET Framework (WPF)
- Visual Studio (doporučeno)
- **Newtonsoft.Json** knihovna (nainstalovat přes NuGet)

## 🚀 Instalace
1. Naklonujte repozitář:
   ```sh
   git clone https://github.com/los-pavlos/CurrencyConverter.git
   cd currency-converter
   ```
2. Otevřete projekt ve **Visual Studio**.
3. Nainstalujte závislosti přes **NuGet Package Manager**:
   ```sh
   Install-Package Newtonsoft.Json
   ```
4. Spusťte aplikaci (`F5`).

## 📌 Použití
1. Zadejte částku k převodu.
2. Vyberte vstupní a cílovou měnu.
3. Klikněte na **"Převést"** pro zobrazení výsledku.

## 🔗 API Zdroj
- [Frankfurter API](https://www.frankfurter.app/)


