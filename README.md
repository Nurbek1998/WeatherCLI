# 🌤️🌍 WeatherCLI

<br>

 🚀 **Tez, oson va terminalda ishlaydigan ob-havo ilovasi**



**Weather CLI** — bu foydalanuvchiga tanlangan shahar bo‘yicha **real vaqtda ob-havo ma’lumotlarini** taqdim etuvchi interaktiv **CLI ilova**.

Ilova foydalanuvchidan shahar nomini tanlashni yoki kiritishni so‘raydi va OpenWeatherMap API orqali ob-havo, temperatura hamda shamol tezligini ko‘rsatadi.



---
## 📦 Xususiyatlar

- 🌐 Har qanday shahar uchun real vaqtdagi ob-havo ma'lumotlari
- 🔍 Tanlov menyusi yoki qo‘lda shahar kiritish imkoniyati
- 📊 Temperaturani, havo holatini va shamol tezligini ko‘rsatadi
- ❌ Mavjud bo‘lmagan shaharlar uchun foydalanuvchiga xatolik haqida ogohlantiradi
- 🛠️ `appsettings.json` fayli orqali API kalitni boshqarish

<br>

## ⚙️ Texnologiyalar
- [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) (.NET 8)
- [Spectre.Console](https://spectreconsole.net/) — interaktiv terminal interfeysi
- [OpenWeatherMap API](https://openweathermap.org/api) — ob-havo ma’lumotlari uchun

<br>

<h3>📸 Ekran ko‘rinishi</h3>

<img src="https://github.com/user-attachments/assets/0a23d7d7-4c99-4358-9a0a-4311a76228b9" width="300"/>

---


## ⚙️ Ishlatish

### 1. API kalitni sozlang

`appsettings.json` faylida quyidagicha `OpenWeather` API kalitni kiriting:

```json
{
  "OpenWeather": {
    "ApiKey": "BU_YERGA_O'ZINGIZNING_API_KALITINGIZNI_QO'YING"
  }
}
