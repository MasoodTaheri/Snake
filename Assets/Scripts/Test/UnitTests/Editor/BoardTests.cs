using System.Collections.Generic;
using Assets.Scripts.Board;
using Assets.Scripts.InputController;
using Assets.Scripts.Snake;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Scripts.Test.UnitTests.Editor
{
    public class BoardTests
    {
        [Test]
        public void CreateBoardWidthIs5()
        {
            // Arrange
            IBoardController _boardController = new BoardController();

            // Act
            _boardController.Initialize(5, 20);


            // Assert
            Assert.That(_boardController.Board.GetLength(0), Is.EqualTo(5));
        }


        [Test]
        public void CreateBoardHeightIs5()
        {
            // Arrange
            IBoardController _boardController = new BoardController();

            // Act
            _boardController.Initialize(85, 5);


            // Assert
            Assert.That(_boardController.Board.GetLength(1), Is.EqualTo(5));
        }

        [TestCase(0, 0, ExpectedResult = GridValue.Wall, TestName = "gridvalue at (0,0)==wall")]
        [TestCase(4, 19, ExpectedResult = GridValue.Wall, TestName = "gridvalue at (4,19)==wall")]
        [TestCase(3, 3, ExpectedResult = GridValue.Empty, TestName = "gridvalue at (3,3)==empty")]
        public GridValue GetGridValue(int x, int y)
        {
            // Arrange
            IBoardController _boardController = new BoardController();

            // Act
            _boardController.Initialize(5, 20);


            // Assert
            return (GridValue)_boardController.Board[x, y];
        }
    }
}
