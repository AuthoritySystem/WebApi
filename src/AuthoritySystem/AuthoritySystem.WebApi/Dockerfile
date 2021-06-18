# 使用运行时镜像
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
# 设置工作目录
WORKDIR /app
# 把目录下的内容都复制到当前目录下
COPY . .
# 暴露80端口
EXPOSE 80
# 设置容器编码格式
ENV LANG C.UTF-8
# 设置时区，解决容器内时间和宿主机时间不一致问题
RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
# 运行镜像入口命令和可执行文件名称
ENTRYPOINT ["dotnet", "AuthoritySystem.WebApi.dll"]