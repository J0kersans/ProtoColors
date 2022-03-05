using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : Feedback
{
    #region Variables

    [SerializeField]
    private ParticleSystem particlePrefab;

    private ParticleSystem particle;

    #endregion

    #region Override

    public override void Play()
    {
        base.Play();

        var particleFX = Instantiate(particle, this.transform);


        particleFX.Play();
    }

    #endregion
}
