﻿(async function () {
    
    const db = await new PouchDB('kanjiDb');

    window.pouchDb = {
        generateIndex: async () => {
            return await db.createIndex({
                index: { fields: ['type'] }
            });
        },
        getByType: async (objectType) => {
            const items = await db.find({
                selector: {
                    type: objectType
                }
            });
            return items.docs;
        },
        getById: async (id) => {
            return await db.get(id);
        },
        getAll: async () => (await db).allDocs({include_docs: true, descending: true}, function(err, doc) {
            console.log(doc);
            return(doc.rows);
        }),
        add: async (value, objectType) => {
            try {
                const updatedDoc = await db.put({...value, type: objectType});
                console.log("ADDING DOCUMENT")
                console.log(updatedDoc);
            }
            catch (err) {
                console.log("ERROR ADDING DOCUMENT")
                console.log(err);
            }
        },
        update: async (value) => {
            try {
                let doc = await db.get(value._id)
                const updatedDoc = await db.put({...doc, ...value});
                console.log("UPDATING DOCUMENT")
                console.log(updatedDoc);
            }
            catch (err) {
                console.log("ERROR UPDATING DOCUMENT")
                console.log(err);
            }
        },
        delete: async (key) => {
            try {
                const doc = await db.get(key);
                const response = await db.remove(doc);
                console.log(response);
            }
            catch (err) {
                console.log(err);
            }
        }
    };
    
})();


