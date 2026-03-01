using UnityEngine;

public class Gun : MonoBehaviour
{
    //xoay súng theo hướng chuột
    private float rotateOffset = 180f; // để điều chỉnh hướng của súng, vì sprite mặc định hướng về phải

    //bắn viên đạn
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 100;    
    public int currentAmmo;
    // tương tác với TextMesh Pro đã tạo bên trong Canvas để hiển thị số đạn hiện tại
    [SerializeField] private TMPro.TextMeshProUGUI ammoText;


    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }

    void RotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
            return;

        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);

        //  tránh lật súng nếu quay quá 90 độ
        if (angle > 90 || angle < -90)
            transform.localScale = new Vector3(1, 1, 1); // giuwxx nguyên
        else
            transform.localScale = new Vector3(1, -1, 1); // lật theo trục y
    }

    void Shoot()
        {
        // 0 tương ứng với nút chuột trái
        if (Input.GetMouseButton(0) && Time.time >= nextShot && currentAmmo > 0)
        {
           Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            nextShot = Time.time + shotDelay;
            currentAmmo--;
            UpdateAmmoText();
        }
    }

    void Reload()
    {
        if(Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo) // 1 tương ứng với nút chuột phải
        {
            currentAmmo = maxAmmo;
        UpdateAmmoText();
        }
    }

    private void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = $"{currentAmmo}";
            if (currentAmmo <= 0)
            {
                ammoText.text = "Empty";
            }
        }

    }
}