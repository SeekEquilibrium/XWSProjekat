class BaseApiClass {
    static requestConfig() {
        return {
            headers: {
                Authorization: "bearer " + window.localStorage.token,
                pragma: "no-cache",
            },
        };
    }
}
export default BaseApiClass;
