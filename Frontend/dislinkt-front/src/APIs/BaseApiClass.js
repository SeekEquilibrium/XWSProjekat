class BaseApiClass {
    static requestConfig() {
        return {
            headers: {
                Authorization: window.localStorage.token,
                pragma: "no-cache",
            },
        };
    }
}
export default BaseApiClass;
