#include <iostream>
#include <windows.h>
#include <string>
#include <comutil.h>
#pragma comment(lib, "comsuppw.lib")

int main() {
    // 加载 DLL
    HMODULE hModule = LoadLibrary(L"Core.dll");
    if (hModule == NULL) {
        std::cerr << "Failed to load core.dll" << std::endl;
        return 1;
    }

    // 获取函数地址
    typedef BSTR(*GetRandomStudentNameFunc)();
    GetRandomStudentNameFunc GetRandomStudentName = (GetRandomStudentNameFunc)GetProcAddress(hModule, "GetRandomStudentName");
    if (GetRandomStudentName == NULL) {
        std::cerr << "Failed to get function address" << std::endl;
        FreeLibrary(hModule);
        return 1;
    }

    // 调用函数
    BSTR bstrStudentName = GetRandomStudentName();
    _bstr_t bstrWrapper(bstrStudentName, false);
    std::wstring studentName = (wchar_t*)bstrWrapper; // 修复错误
    std::wcout << L"Random student name: " << studentName << std::endl;

    // 释放 DLL
    FreeLibrary(hModule);
    return 0;
}
