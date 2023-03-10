using System.Collections.Generic;
using Assets.Scripts.Board;
using UnityEngine;

namespace Assets.Scripts.GridCell
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _emptyCell;
        [SerializeField] private Sprite _wallCell;
        [SerializeField] private Sprite _snakeCell;
        [SerializeField] private Sprite _foodCell;

        //private Dictionary<gridValue, Sprite> _spriteDataBase;


        public void SetCell(GridValue value)
        {
            if (value == GridValue.Empty)
                _spriteRenderer.sprite = _emptyCell;
            if (value == GridValue.Wall)
                _spriteRenderer.sprite = _wallCell;     
            if (value == GridValue.Snake)
                _spriteRenderer.sprite = _snakeCell;
            if (value == GridValue.Food)
                _spriteRenderer.sprite = _foodCell;
        }
    }
}
