(function () {
    window.generateStrokeOrder = (id, value) => {
        const writer = HanziWriter.create(id, value, {
            width: 150,
            height: 150,
            padding: 20,
            delayBetweenLoops: 2000,
            charDataLoader: (char, onLoad, onError) => {
                fetch(`https://cdn.jsdelivr.net/npm/hanzi-writer-data-jp@0/${char}.json`)
                    .then(res => res.json())
                    .then(onLoad)
                    .catch(onError);
            }
        });
        writer.loopCharacterAnimation();
    };
})();