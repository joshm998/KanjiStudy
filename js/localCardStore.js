(function () {

    const db = idb.openDB('Cards', 1, {
        upgrade(db) {
            db.createObjectStore('cardstore', { keyPath: 'id' }).createIndex('lastUpdated', 'lastUpdated');
            db.createObjectStore('statstore', { keyPath: 'date' }).createIndex('lastUpdated', 'lastUpdated');
        },
    });

    window.localCardStore = {
        get: async (storeName, key) => (await db).transaction(storeName).store.get(key),
        getAll: async (storeName) => (await db).transaction(storeName).store.getAll(),
        getFirstFromIndex: async (storeName, indexName, direction) => {
            const cursor = await (await db).transaction(storeName).store.index(indexName).openCursor(null, direction);
            return (cursor && cursor.value) || null;
        },
        put: async (storeName, key, value) => (await db).transaction(storeName, 'readwrite').store.put(value, key === null ? undefined : key),
        putAllFromJson: async (storeName, json) => {
            const store = (await db).transaction(storeName, 'readwrite').store;
            JSON.parse(json).forEach(item => store.put(item));
        },
        delete: async (storeName, key) => (await db).transaction(storeName, 'readwrite').store.delete(key),
    };
})();