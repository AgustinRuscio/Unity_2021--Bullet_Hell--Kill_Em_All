using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerController
{
    private PlayerModel model;

    private event Action movementMethods;
    private event Action MouseMethods;
    private event Action systemMethods;

    public PlayerController(PlayerModel model)
    {
        this.model = model;
        SetActions();

    }

    private void SetActions()
    {
        movementMethods += MovementController;

        MouseMethods += MouseRotation;
        MouseMethods += Fire;

        systemMethods += PauseGame;
    }

    public void MovementMethods() => movementMethods();
    

    public void WeaponMethods() => MouseMethods();
    public void SystemMethods() => systemMethods();
    

    public void MovementController() => model.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    
    public void Fire() => model.Fire(Input.GetMouseButton(0));
    

    public void MouseRotation() => model.RotatePlayer(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y)));
    
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EventManager.Trigger(EventEnum.PauseGame, true);

        if (Input.GetKeyDown(KeyCode.E))
            model.NextWeapon();

        if (Input.GetKeyDown(KeyCode.Q))
            model.PrevWeapon();

    }
}