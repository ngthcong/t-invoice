import createStore from 'unistore'

// Create a global store to store variable in
// Usually changing its state will invoke React component change events 
// To learn more about store, visit https://github.com/developit/unistore
var store = createStore({
    count: 0
})

// Reducer (Action) concept
// To invoke changes on store, reducer only contains function that modify the global state.
export const reducer = {
    increaseCount: ({ count }) => ({ count: count+1 }),
    increaseCountBy: ({ count }, value)=> ({count: count + value }),
    resetCount: (state) => ({ count: 0 })
}

export default store