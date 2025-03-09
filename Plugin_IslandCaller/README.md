# IslandCaller

IslandCaller 是一个基于 ClassIsland 提醒服务的轻量级点名器，用于在课堂上快速点名。

## 特性

- 快速点名：输入班级名单后，可以通过桌面快捷方式快速点名。
- 简单易用：通过插件商店下载并进行基本配置即可使用。
- 集成 ClassIsland：依赖 ClassIsland 的提醒服务，通过注册 URL 协议实现快速点名。


## 使用方法

1. **下载插件：** 从 ClassIsland 插件商店下载 `IslandCaller` 插件。

2. **创建快捷方式：**
   在插件设置中创建桌面快捷方式，或者自行创建一个指向 `classisland://plugins/IslandCaller/Run` 的快捷方式。

3. **输入并保存班级名单：**
   在设置中输入你的班级名单，每行一个学生姓名，并保存设置。

4. **运行快捷方式进行点名：**
   点击桌面上的快捷方式，打开 `IslandCaller` 插件并进行点名。

## 注意事项

- 确保 ClassIsland 本体的“注册 Url 协议”设置已开启，否则无法通过快捷方式启动插件。

## 致谢

本项目使用了以下第三方库：
- [ClassIsland.PluginSdk](https://github.com/ClassIsland/ClassIsland/)

## 许可

本项目使用 GPL3 许可证进行开源，详细信息请查看 [LICENSE](LICENSE) 文件。

---

如果你在使用过程中遇到任何问题，欢迎提交 [issue](https://github.com/HUSX100/IslandCaller/issues)。

---

感谢你使用 IslandCaller，希望它能为你的课堂管理带来便利！
