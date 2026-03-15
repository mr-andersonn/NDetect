# NDetect

<br>
Have you ever thought to yourself, "Is someone connected to my network and  spying on me right now?". You open your terminal in cold sweat, type in nmap ... Nothing... Well that was close. Maybe next time you will catch an unauthorized device. 

But what if instead of scanning the network manually, you could just open an app that does it for you with the chosen frequency, save all the devices it finds and notify you about all of the Unauthorized devices?

**NDetec**(Network Detective) is a project that I built to solve this exact problem. 

It is a cross-platform network scanner built with [Avalonia UI](https://avaloniaui.net/). 
It it very lightweight and has all the necessary functionality to scan your network every **n** seconds, manage all the identified devices with CRUD operations connected to user-friendly UI.

Stays hidden on **Minimized** so it doesn't trigger your OCD.
Open by clicking on the tray icon.

<br><br>

## 📸 Features

🌐 **ARP-based LAN scanning**: The app runs a loop that performs an arp scan every n seconds (10 by default). Every iteration displays a list of detected devices that you can choose to save to the apps sqlite database. 

💾 **Scan history tracking** All the devices are stored in the local SQLite database. In **Devices** window you can manage all the devices, edit them, delete or add new manually.   

✅ Cross-platform: works on **Linux**, **Windows**, and **macOS**

<br><br>

## 🛠 Requirements

- [.NET 7.0 or later](https://dotnet.microsoft.com/download)
- Basic knowledge in networking. The app gives you MAC and IP of every detected device. You will have to manually find out which device in your house is being detected by the scanner. Check: Phones, Tablets, Laptops, PCs etc.
- If you don't know how to do it --> Use Google or ask ChatGPT;

<br><br>

## 📦 Build & Run 

Currently there is no executable but the project can be opened with Rider / VS and run from there.

The app, however, is ready for publishing so just google "How to publish in Rider/VisualStudio". When publishing --> Coose "Produce single file". Otherwise you will get 100+ dlls in your output dir.


