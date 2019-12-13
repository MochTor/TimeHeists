using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Animation _mainAnimation;
    private Camera _camera;
    private AnimationState _lastPlayedAnimationClip;
    private string _lastPlayedAnimationClipName;

    private void Start()
    {
        _mainAnimation = GetComponent<Animation>();
        _camera = GetComponent<Camera>();
        _lastPlayedAnimationClip = new AnimationState();
    }

    public void BackButtonAnimation()
    {
        _mainAnimation.Play(_lastPlayedAnimationClipName);
        _lastPlayedAnimationClip.speed = -1.0f;
        _lastPlayedAnimationClip.time = _lastPlayedAnimationClip.length;
    }

    public void MainMenuToHeroGallery()
    {
        _mainAnimation.Play("MainMenuToHeroGalleryCamAnimation");
        //_lastPlayedAnimationClip = _mainAnimation["MainMenuToHeroGalleryCamAnimation"];
        //_lastPlayedAnimationClipName = "MainMenuToHeroGalleryCamAnimation";
    }

    public void HeroGalleryToVikings()
    {
        _mainAnimation.Play("HeroGalleryToVikingIsland");
        //_lastPlayedAnimationClip = _mainAnimation["HeroGalleryToVikingIsland"];
        //_lastPlayedAnimationClipName = "HeroGalleryToVikingIsland";
    }

    public void HeroGalleryToMainMenu()
    {
        _mainAnimation.Play("HeroGalleryToMainMenuCamAnimation");
    }
}
