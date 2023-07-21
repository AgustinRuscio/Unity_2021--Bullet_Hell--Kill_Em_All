//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView 
{
    private Animator Animator;

    private Slider _slider;
    private float _maxLife;

    private Image _rifleImage;
    private Image _shotGunImage;
    private Image _rocketLuncherImage;

    private Dictionary<string, Image> _weapons = new Dictionary<string, Image>();

    public PlayerView(float maxLife) => _maxLife = maxLife;
    

    public PlayerView SetImages(List<Image> images)
    {
        _rifleImage = images[0];
        _weapons.Add("Rifle", _rifleImage);

        _shotGunImage = images[1];
        _weapons.Add("ShotGun", _shotGunImage);

        _rocketLuncherImage = images[2];
        _weapons.Add("Rocket Luncher", _rocketLuncherImage);

        return this;
    }

    public PlayerView SetSlider(Slider slider)
    {
        _slider = slider;
        return this;
    }

    public PlayerView SetAnimator(Animator animator)
    {
        Animator = animator;
        return this;
    }


    public void MovingAnim(float x, float z)
    {
        Animator.SetFloat("x", x);
        Animator.SetFloat("z", z);
    }

    public void SetDeath() => Animator.SetTrigger("Death");
    public void SetFire(bool fire) => Animator.SetBool("Fire", fire);

    public void UpdateLifeBar(float health) => _slider.value = health / _maxLife;
    public void UpdateWeaponSelected(string weapon)
    {
        foreach (KeyValuePair<string, Image> image in _weapons)
        {
            image.Value.color = Color.gray;
        }
        Animator.SetTrigger("ChangeWeapon");
        

        if (_weapons.ContainsKey(weapon))
            _weapons[weapon].color = Color.white;
    }
}