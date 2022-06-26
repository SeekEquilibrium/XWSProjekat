import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Provider } from "react-redux";
import store from "./redux/store";

import { NavigationBar } from "./components/NavigationBar/NavigationBar";
function App() {
    return (
        <Provider store={store}>
            <div className="App">
                <NavigationBar />
            </div>
        </Provider>
    );
}

export default App;
