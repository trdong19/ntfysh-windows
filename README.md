# ntfy.sh Windows

ntfy.sh Windows 是一个轻量级的 Windows 推送通知客户端，用于接收通过 https://ntfy.sh 兼容服务器发送的通知。

支持同时从多个 ntfy.sh 服务器通过 WebSocket 或 HTTP 接收通知，支持需要认证和无需认证的主题。

## 截图
### 主界面
![Application screenshot](https://user-images.githubusercontent.com/33007665/206556170-962fd699-988c-477e-941e-5179b9f4a67c.png)
![Topic Subscribe screenshot](https://user-images.githubusercontent.com/33007665/206556398-5ee95cee-6fc8-4234-b46e-6380cdfc94dd.png)
![Settings screenshot](https://user-images.githubusercontent.com/33007665/207159693-40542c12-1669-4f32-b1c6-4a8542ac1539.png)

### 通知示例
![Default toast](https://user-images.githubusercontent.com/33007665/206558550-9903b9e3-7f6b-418d-8a46-1311708b5b3e.png)
![High priority toast](https://user-images.githubusercontent.com/33007665/206558687-92a6c6ae-2583-400b-952b-3cdb7fe38c07.png)
![Medium priority toast](https://user-images.githubusercontent.com/33007665/206559209-2f052fc2-4e8a-4ccb-b6cd-4a8066f9c8d7.png)
![image](https://user-images.githubusercontent.com/33007665/206559650-b6b961cc-c764-4d0a-bc49-84e51b23c86f.png)

## 命令行参数

| 参数 | 说明 |
|------|------|
| `-h` / `--help` | 显示帮助菜单 |
| `-t` / `--start-in-tray` | 启动时最小化到系统托盘（适合开机自启） |
| `-m` / `--allow-multiple-instances` | 允许运行多个实例 |

## 功能特性

- 支持 WebSocket 和 HTTP 长轮询两种连接方式
- 支持 Windows 原生通知和自定义托盘通知
- 深色/浅色主题切换
- 支持开机自动启动（在设置中开启）
- 支持多服务器多主题同时订阅
- 单实例运行（可通过 `-m` 参数覆盖）

## 构建

项目使用 .NET 6.0 + WinForms 构建。

```bash
# 构建
dotnet build ntfysh_client/ntfysh_client.csproj

# 发布（自包含单文件）
dotnet publish ntfysh_client/ntfysh_client.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## GitHub Actions

推送 `v*` 标签时自动构建并发布 Release，包含 `win-x64` 和 `win-x86` 两个版本。
