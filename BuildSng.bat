@echo off

echo Build CefSharp.Core...
%devenv% CefSharp3.sln /ReBuild Release /Project CefSharp.Core /ProjectConfig "Release|x64"
if not %errorlevel% equ 0 exit %errorlevel%
%devenv% CefSharp3.sln /ReBuild Release /Project CefSharp.Core /ProjectConfig "Release|Win32"
if not %errorlevel% equ 0 exit %errorlevel%

echo Build CefSharp.BrowserSubprocess.Core...
%devenv% CefSharp3.sln /ReBuild Release /Project CefSharp.BrowserSubprocess.Core /ProjectConfig "Release|x64"
if not %errorlevel% equ 0 exit %errorlevel%
%devenv% CefSharp3.sln /ReBuild Release /Project CefSharp.BrowserSubprocess.Core /ProjectConfig "Release|Win32"
if not %errorlevel% equ 0 exit %errorlevel%

echo Build CefSharp...
%devenv% CefSharp3.sln /ReBuild "Release|AnyCPU" /Project CefSharp /ProjectConfig "Release|AnyCPU"
if not %errorlevel% equ 0 exit %errorlevel%

echo Build CefSharp.BrowserSubprocess...
%devenv% CefSharp3.sln /ReBuild "Release|AnyCPU" /Project CefSharp.BrowserSubprocess /ProjectConfig "Release|AnyCPU"
if not %errorlevel% equ 0 exit %errorlevel%


echo Build CefSharp.Wpf...
%devenv% CefSharp3.sln /ReBuild "Release|AnyCPU" /Project CefSharp.Wpf /ProjectConfig "Release|AnyCPU"
if not %errorlevel% equ 0 exit %errorlevel%


