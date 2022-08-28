export default class BaseService {
    CONTROLLER = "controller";
    ACTION = "action";

    constructor(pathPattern) {
        if (pathPattern.includes(this.CONTROLLER) == false)
            throw new Error("controller is not defined");

        if (pathPattern.includes(this.ACTION) == false)
            throw new Error("action is not defined");

        this.pathPattern = pathPattern;
    }

    getPath(controller, action) {
        return this.pathPattern
            .replace(this.CONTROLLER, controller)
            .replace(this.ACTION, action);
    }

    add(...data) {
        throw new Error("method add not implemented");
    }

    delete(...data) {
        throw new Error("method add not implemented");
    }

    update(...data) {
        throw new Error("method add not implemented");
    }
}