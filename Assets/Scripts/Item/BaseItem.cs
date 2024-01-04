namespace Item
{
    using System;
    using UnityEngine;

    public class BaseItem : MonoBehaviour
    {
        [SerializeField] private ItemModel  item;
        private                  bool    isDragging = false;
        private                  Camera  mainCamera;
        private                  Vector3 offset;

        private void Start()
        {
            mainCamera = GameManager.Instance.Camera;
        }

        void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        GameManager.Instance.screenInfo.UpdateText(nameText: this.item.itemName, infoText: this.item.info);
                        isDragging                           = true;
                        // Tính và lưu trữ sự chênh lệch giữa vị trí chuột và vị trí đối tượng
                        offset = transform.position - hit.point;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging                           = false;
            }

            if (isDragging)
            {
                DragObject();
            }
        }

        void DragObject()
        {
            Ray        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = new Vector3(hit.point.x + offset.x, transform.position.y, hit.point.z + offset.z);
                // Cập nhật vị trí của đối tượng
                transform.position = targetPosition;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.LogError("adadada");
            if (other.CompareTag("Molecules"))
            {
                GameManager.Instance.curentLevel.OnChemicalReaction();
            }
        }
    }
[Serializable]
    public class ItemModel
    {
        public string itemName;
        public string info;
    }
}