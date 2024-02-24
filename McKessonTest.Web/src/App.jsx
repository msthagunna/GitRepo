// import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import viteLogo from '/vite.svg'
import './App.css'
import Search from './components/search'

function App() {
  //const [count, setCount] = useState(0)

  return (
    <>
    <div className="App">
      <h1 className="app-header">Simple Search Panel</h1>
      <Search />
    </div>
    </>
  )
}

export default App
