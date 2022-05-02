using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class RallyObjectMeshWriter : MonoBehaviour
    {
        [SerializeField] private string word = string.Empty;
        [SerializeField] private Letters letters = null;
        [SerializeField] private float letterDistance = 1f;
        [SerializeField] private Material matLetters = null;
        private List<GameObject> wordLetters = new List<GameObject> ();
        private List<MeshRenderer> meshRenderers = new List<MeshRenderer> ();
        private Transform myTransform = null;

        internal void Init()
        {
            this.myTransform = this.GetComponent<Transform>();
            //this.WriteWord(this.word);
        }

        internal void SetRenderMaterial(Material mat)
        {
            this.meshRenderers = this.GetComponentsInChildren<MeshRenderer>().ToList();
            this.meshRenderers.ForEach(i => i.material = mat);
        }

        [Button("Rebuild")]
        internal void WriteWord(string word)
        {
            this.word = word.ToLower();
            this.DestroyOldWord();
            this.CreateWord();
        }

        private void DestroyOldWord()
        {
            for(int i = this.myTransform.childCount-1; i >= 0; i--)
            {
                Destroy(this.myTransform.GetChild(i).gameObject);
            }
            this.wordLetters.Clear ();
            this.meshRenderers.Clear();
        }

        private void CreateWord()
        {
            for (int i = word.Length-1; i >= 0 ; i--)
            {
                if (this.letters.LetterObjects.ContainsKey(word[i]))
                {
                    GameObject letter = GameObject.Instantiate(this.letters.LetterObjects[word[i]], this.myTransform);
                    letter.name = "letter_" + word[i];
                    Transform tLetter = letter.GetComponent<Transform>();
                    tLetter.localPosition = new Vector3((this.letterDistance * (word.Length-i)), 0f, 0f);
                    this.wordLetters.Add(letter);
                }
            }
            this.myTransform.localPosition = new Vector3 (-((this.letterDistance*word.Length)/2f), this.myTransform.localPosition.y, this.myTransform.localPosition.z);
            this.meshRenderers = this.GetComponentsInChildren<MeshRenderer>().ToList();
        }
    }
}
