import React from 'react'

const modules = {}
// React context allow you to inject value to all nesting components, where to can get it later by using React.useContext(Context-You-Created-Before)
// For more information: https://reactjs.org/docs/hooks-reference.html#usecontext
const AppModule = React.createContext(modules)

// This provider should be put in the parent component
export const AppModuleProvider = ({ children })=>{
    return <AppModule.Provider value={modules}>
        {children}
    </AppModule.Provider>
}

export default AppModule