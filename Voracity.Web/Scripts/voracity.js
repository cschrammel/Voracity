
var Tile = function (x, y, number) {
    var self = this;
    self.x = ko.observable(x);
    self.y = ko.observable(y);
    self.number = ko.observable(number);
    self.isCurrent = ko.observable(false);
    self.isFlipped = ko.observable(false);
    self.flip = function () {
        this.isFlipped(true);
    };
};

function ViewModel() {
    var self = this;

    self.tiles = ko.observableArray();

    self.score = ko.observable(0);

    self.startGame = function () {
        this.startOver();
        this.randomizeTiles();
        this.randomizeStart();
    };

    self.startOver = function () {
        self.tiles.removeAll();
    };

    self.randomizeTiles = function () {
        for (var x = 1; x <= 10; x++) {
            for (var y = 1; y <= 10; y++) {
                var randomNumber = 1 + Math.floor(Math.random() * 8);
                var tile = new Tile(x, y, randomNumber);
                self.tiles.push(tile);
            }
        }
    };

    self.randomizeStart = function () {
        var randomIndex = Math.floor(Math.random() * 100);
        var t = self.tiles()[randomIndex];
        t.isCurrent(true);
        self.currentIndex = randomIndex;
    };

    self.hasMovesLeft = function () {
        if ((!self.canMove(self.currentIndex - 1))
        && (!self.canMove(self.currentIndex - 9))
        && (!self.canMove(self.currentIndex - 10))
        && (!self.canMove(self.currentIndex - 11))
        && (!self.canMove(self.currentIndex + 1))
        && (!self.canMove(self.currentIndex + 9))
        && (!self.canMove(self.currentIndex + 10))
        && (!self.canMove(self.currentIndex + 11))) return false;
        return true;
    };

    self.canMove = function (index) {
        if (index < 0 || index >= 100) return false;

        var tile = self.tiles()[index];
        var tileIndex = tile.y() + (tile.x() * 10 - 10) - 1;
        var dif = tileIndex - self.currentIndex;
        var canMove = true;

        // overlap detection
        for (var i = 0; i < tile.number() ; i++) {
            var flipIndex = tileIndex + (i * dif);
            var flipTile = self.tiles()[flipIndex];
            if (flipIndex < 0 || flipIndex >= 100 || flipTile.isFlipped() === true) canMove = false;
        }

        // edge detection
        var currentTile = self.tiles()[self.currentIndex];
        // left
        if ((dif === -1 || dif === -1 * (10 + 1) || dif === 10 - 1) && currentTile.y() - tile.number() < 1) canMove = false;
        // right
        if ((dif === 1 || dif === -1 * (10 - 1) || dif === 10 + 1) && currentTile.y() + tile.number() > 10) canMove = false;
        // up
        if ((dif === -10 || dif === -1 * (10 - 1) || dif === -1 * (10 + 1)) && currentTile.x() - tile.number() < 1) canMove = false;
        // down
        if ((dif === 10 || dif === 10 + 1 || dif === 10 - 1) && currentTile.x() + tile.number() > 10) canMove = false;
        return canMove;
    };

    self.move = function (tile) {
        var tileIndex = tile.y() + (tile.x() * 10 - 10) - 1;
        var dif = tileIndex - self.currentIndex;
        var isSurroundingTile =
            dif === -1 * (10 - 1) || dif === -10 || dif === -1 * (10 + 1) ||
                dif === -1 || dif === 1 ||
                dif === 10 - 1 || dif === 10 || dif === 10 + 1;

        if (isSurroundingTile) {
            var canFlip = self.canMove(tileIndex);
            if (canFlip) {
                for (var i = 0; i < tile.number() - 1; i++) {
                    var flipIndex = tileIndex + (i * dif);
                    self.tiles()[flipIndex].flip();
                }
                self.tiles()[self.currentIndex].flip();
                self.tiles()[self.currentIndex].isCurrent(false);
                var newCurrentIndex = tileIndex + (dif * (tile.number() - 1));
                self.tiles()[newCurrentIndex].isCurrent(true);
                self.currentIndex = newCurrentIndex;
                self.score(self.score() + tile.number());
                if (self.hasMovesLeft() == false) alert('Game over.  Your final score is ' + self.score() + '.');
            }
        }
    };
};
