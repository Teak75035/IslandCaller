#include "pch.h"
using namespace std;


// DllMain
BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}


//点名器函数
string GetRandomStudent(const wchar_t* filenameW, int number)
{
    wstring wstr(filenameW);
    string filename(wstr.begin(), wstr.end());
    ifstream file(filename);
    if (!file) {
        MessageBox(NULL, (L"Failed to open: " + wstring(filename.begin(), filename.end())).c_str(), L"Error", MB_ICONERROR);
        return "Error";
    }

    vector<string> students;
    string name;
    while (getline(file, name)) {
        students.push_back(name);
    }
    file.close();

    // 检查名单是否为空
    if (students.empty()) {
        MessageBox(NULL, L"Namelist is empty!", L"Error", MB_ICONERROR);
        return "Error";
    }

    // 随机抽取学生
    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> dist(0, students.size() - 1);
    int randomIndex = dist(gen);
    return students[randomIndex];
}

//EXPORT wstring GetRandomStudent
EXPORT_DLL BSTR GetRandomStudentName(/*wstring filename, int number*/) {
    wstring filename = L".\\Config\\Plugins\\Plugin.IslandCaller\\default.txt";
    int number = 1;
    string name = GetRandomStudent(filename.c_str(), number);
    wstring_convert<codecvt_utf8_utf16<wchar_t>> converter;
    wstring wstr = converter.from_bytes(name);
    return SysAllocString(wstr.c_str());
}