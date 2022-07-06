import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Provider } from "react-redux";
import store from "./redux/store";

import { NavigationBar } from "./components/NavigationBar/NavigationBar";
import {
    BrowserRouter as Router,
    Route,
    Routes,
    Navigate,
} from "react-router-dom";
import { UserInfo } from "./components/UserInfo/UserInfo";
import { Registration } from "./components/Registration/Registration";
import { Login } from "./components/Login/Login";
function App() {
    const isSignedIn = !!localStorage.getItem("token");
    console.log("isSignedIn", isSignedIn);
    return (
        <Provider store={store}>
            <Router>
                <div className="App">
                    <NavigationBar />
                </div>
                <div className="Main_Content">
                    <Routes>
                        <Route path="/user/:id" element={<UserInfo />} />
                        {!isSignedIn && (
                            <>
                                <Route
                                    path="/registration"
                                    element={<Registration />}
                                />
                                <Route path="/login" element={<Login />} />
                            </>
                        )}
                        {/* <Route path="*" element={<Navigate to="/" replace />} /> */}
                    </Routes>
                </div>
            </Router>
        </Provider>
    );
}

export default App;
