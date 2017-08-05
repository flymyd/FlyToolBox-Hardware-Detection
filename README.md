# FlyToolBox Hardware Detection
## A Free and Open Source Hardware Detection tool
## A product of resentment
My major is computer. So sometimes my friends' computer(most are laptops) crashes or slows down ,they will contact me to find help. But we know--in most cases, the causes are from their HDD or poor graphic card. So I will know their hareware specification.
But, If I ask them to install LuDaShi, a popular hardware detection toolbox in China, they will click "Next" without pay attention to the hint of binding software...
Not only that, it also has other drawbacks. For example, we know that the laptop usually has two graphics cards, An integrated Intel HD Graphics and a Nvidia(or an AMD) external graphic card. But if they exist at the same time, LuDaShi only can shows HD Graphics.This situation also occurs when HDD and SSD exist simultaneously.
So I wrote this program.
## Features compared with similar products
This tool can shows ALL graphic cards and disk drive because I formatted the information string from WMI interface.
Some people do not know how to screenshot. So this tool have a button which can auto save its result as a picture on your desktop.
## How to use it
This tool is in /FlyToolBox-Hardware-Detection/飞翔工具箱硬件检测/bin/Debug/. Just download it and double click. Need .Net Framework 4.0.
## License statement
This tool is protected by GNU GPL V3 License. You can use it for free. 

# 飞翔工具箱硬件检测小工具
## 怨念下的产物
我是个计算机专业的学生，总有人嫌电脑卡了或者崩了来找我修。我总得知道具体配置吧？虽然基本都是垃圾显卡或者垃圾机械硬盘的锅。鲁大师身上绑一大堆推广软件，小白一路下一步肯定会中招。而且双显卡或双硬盘的时候鲁大师硬件检测的首页只显示一个。挺蛋疼的。所以写了这个程序。
## 比起同类软件的特点
用了Windows自带的WMI接口，多写了个循环而已，就可以同时显示多硬盘和多显卡。有的小白连截图都不会，为了避免被手机拍的干涉条纹晃瞎眼，我还加了个一键截图的功能，可与把截图保存在桌面上。
## 使用方法
在/FlyToolBox-Hardware-Detection/飞翔工具箱硬件检测/bin/Debug/下找到这个软件的本体。其它的都是源码。双击就能用。需要.Net Framework 4.0，一般都有的。
## 许可声明
这个工具被GNU GPL V3协议保护。代码也很简单，随便用，别直接抄就行。
