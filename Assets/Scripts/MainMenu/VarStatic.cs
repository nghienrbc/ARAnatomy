using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarStatic : MonoBehaviour {

    public static int _language = 0;
    public static string _levelSelect = "LvXuong";
    public static bool Back;
    public static string _IsSystemSave = "Skeletal System"; // Biến này dùng để lưu trữ tạm hệ đang load
                                     // Lúc bấm back thì nó sẽ load biến này để load hệ đang load hiện tại
}
