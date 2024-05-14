
public class ListeVideException extends RuntimeException {
    public ListeVideException() {
    }

    public ListeVideException(String message) {
        super(message);
    }

    public ListeVideException(String message, Throwable cause) {
        super(message, cause);
    }

    public ListeVideException(Throwable cause) {
        super(cause);
    }

    public ListeVideException(String message, Throwable cause, boolean enableSuppression, boolean writableStackTrace) {
        super(message, cause, enableSuppression, writableStackTrace);
    }
}
