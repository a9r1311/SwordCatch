using UnityEngine;

namespace Kamatte.ID
{
    [RequireComponent(typeof(ObjectRegistry))]
    //  オブジェクトID自動生成
    [ExecuteInEditMode]
    public class IDGenerater : MonoBehaviour
    {
        [SerializeField] private IDCategory Category = IDCategory.UNDEFINED;   // 種類例：Player, Enemy
        [SerializeField] private IDLabel Label = IDLabel.UNDNAMED;        // 意味例：Main, Boss
        [Header("Emptyになると自動生成")]
        [SerializeField] private string ID = "";            // 自動生成されるID

        public IDCategory CategoryProperty => Category;    //  カテゴリープロパティ
        public IDLabel LabelProperty => Label;    //  ラベルプロパティ

        public string CategoryAsStringProperty => IDEnumToString.ToString(Category);    //  カテゴリプロパティ(文字列出力)
        public string LabelAsStringProperty => IDEnumToString.ToString(Label);    //  ラベルプロパティ(文字列出力)
        public string IDProperty => ID;    //  IDプロパティ
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(ID))
            {
                ID = $"{CategoryAsStringProperty}_{LabelAsStringProperty}_{System.Guid.NewGuid().ToString("N").Substring(0, 8)}";
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
#endif
            }
        }
    }
}